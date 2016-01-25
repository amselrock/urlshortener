(function() {
    'use strict';

    angular
        .module('app')
        .directive('urlStatistics', urlStatistics);

    urlStatistics.$inject = ['siteRootUrl'];
    
    function urlStatistics(siteRootUrl) {
        // Usage:
        //     <url_statistics></url_statistics>
        // Creates:
        // 
    	var directive = {
			scope: true,
        	bindToController: {
				urlCode: '@'
        	},
        	controller: urlStatisticsController,
        	controllerAs: 'vm',
        	templateUrl: siteRootUrl + 'Scripts/app/url-statistics/url-statistics.template.html',
        	restrict: 'EA'
    	};

        return directive;
    }

    urlStatisticsController.$inject = ['$scope', '$filter', 'appService', 'siteRootUrl', 'blockUI'];
    function urlStatisticsController($scope, $filter, appService, siteRootUrl, blockUI) {
    	var vm = this;

    	activate();

    	function activate() {
    		blockUI.start();

    		// set url code (short Url)
    		vm.root = siteRootUrl;

    		// chart congiguration
    		vm.chart = {
    			data: [],
    			labels: [],
    			series: [],
    			options: {
    				bezierCurve: false,
    				pointHitDetectionRadius: 1
    				//// Boolean - If we want to override with a hard coded scale
    				//scaleOverride: true,

    				//// ** Required if scaleOverride is true **
    				//// Number - The number of steps in a hard coded scale
    				//scaleSteps: 1
    			}
    		};

    		$scope.$watch('vm.stats.items', function (newValue, oldValue) {
    			if (newValue != oldValue) {
    				DrawStatisticsGraph();
    			}
    		});

    		// attach statitistics source by reference
    		vm.stats = appService.getStats();

    		// load stats
    		appService.loadStats(vm.urlCode);

    		// get url info
    		GetUrl();
    	}

    	function GetUrl() {
    		// get the url properties
    		var promise = appService.getUrl(vm.urlCode);
    		promise.then(complete).catch(throwException);

    		function complete(data) {
    			vm.url = data;
    		}
    	}

    	// Draws the graph
    	function DrawStatisticsGraph() {
    		vm.chart.data = [];
    		vm.chart.labels = [];
    		vm.chart.series = ['Views'];

    		if (angular.isDefined(vm.stats) && angular.isDefined(vm.stats.items) && vm.stats.items.length > 0) {
    			vm.chart.data[0] = [];

    			$.each(vm.stats.items, function (j, item) {
    				vm.chart.data[0].push(item.count);
    				vm.chart.labels.push($filter('date')(item.date, 'dd/MM/yyyy'));
    			});
    		}
    		else {
    			vm.chart.data = [0];
    			vm.chart.labels = [''];
    			vm.chart.series = [''];
    		}

    		blockUI.stop();
    	}

    	// show error message
    	function throwException(e) {
    		if (angular.isDefined(e.data) && angular.isDefined(e.data.Message)) {
    			vm.errorMessage = e.data.Message
    		}
    		else {
    			vm.errorMessage = 'An error has occurred';
    		}

    		// hide error message after 3s
    		$timeout(function () {
    			vm.errorMessage = '';
    		}, 3000);
    	}
    }
})();