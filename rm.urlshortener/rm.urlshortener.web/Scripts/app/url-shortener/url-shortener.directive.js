(function () {
	'use strict';

	angular
        .module('app')
        .directive('urlShortener', urlShortener);

	urlShortener.$inject = ['siteRootUrl'];

	function urlShortener(siteRootUrl) {
		// Usage:
		//     <url-shortener></url-shortener>
		// Creates:
		// 
		var directive = {
			scope: true,
			bindToController: true,
			controller: urlShortenerController,
			controllerAs: 'vm',
			templateUrl: siteRootUrl + 'Scripts/app/url-shortener/url-shortener.template.html',
			restrict: 'EA'
		};
		return directive;
	}

	urlShortenerController.$inject = ['$scope', '$timeout', 'appService', 'siteRootUrl', 'blockUI'];
	function urlShortenerController($scope, $timeout, appService, siteRootUrl, blockUI) {
		var vm = this;

		activate();

		function activate() {
			vm.submitUrl = SubmitUrl;
			vm.errorMessage = '';
			vm.successMessage = '';
		}

		function SubmitUrl() {
			blockUI.start();

			var promise = appService.addUrl(vm.longUrl);
			promise.then(complete).catch(throwException).finally(final);

			function complete(addedUrl) {
				vm.successMessage = 'URL successfully added!';
				vm.longUrl = '';
				$scope.urlShortenerForm.$setPristine();
				$scope.urlShortenerForm.$setUntouched();
				vm.submitted = false;

				// hide error message after 3s
				$timeout(function () {
					vm.successMessage = '';
				}, 3000);
			}
		}

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

		function final() {
			blockUI.stop();
		}
	}
})();