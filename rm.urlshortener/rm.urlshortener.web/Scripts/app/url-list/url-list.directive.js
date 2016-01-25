(function () {
	'use strict';

	angular
        .module('app')
        .directive('urlList', urlList);

	urlList.$inject = ['siteRootUrl'];

	function urlList(siteRootUrl) {
		// Usage:
		//     <url-list></url-list>
		// Creates:
		// 
		var directive = {
			scope: true,
			controller: urlListController,
			controllerAs: 'vm',
			templateUrl: siteRootUrl + 'Scripts/app/url-list/url-list.template.html',
			restrict: 'EA'
		};

		return directive;
	}

	urlListController.$inject = ['$timeout', 'appService', 'siteRootUrl', 'blockUI'];
	function urlListController($timeout, appService, siteRootUrl, blockUI) {
		var vm = this;

		activate();

		function activate() {
			vm.siteRootUrl = siteRootUrl;
			vm.urls = appService.getUrls();

			vm.errorMessage = '';

			LoadUrls();
		}

		function LoadUrls() {
			blockUI.start();

			var promise = appService.loadUrls();
			promise.then(complete).catch(throwException).finally(final);

			function complete(data) {
			}
		}

		function throwException(e) {
			if (angular.isDefined(e.data) && angular.isDefined(e.data.Message)) {
				vm.errorMessage = e.data.Message;
			}
			else {
				vm.errorMessage = 'An error has occurred';
			}

			// hide error message after 3s
			$timeout(function () {
				vm.errorMessage = '';
			}, 3000);
		}

		function final() {
			blockUI.stop();
		}
	}
})();