(function () {
	'use strict';

	angular
        .module('app')
        .factory('appService', appService);

	appService.$inject = ['$http', '$q', 'siteRootUrl'];

	function appService($http, $q, siteRootUrl) {
		var urls = {
			items: []
		};

		var stats = {
			items: []
		};

		var service = {
			addUrl: AddUrl,
			getUrl: GetUrl,
			loadUrls: LoadUrls,
			getUrls: GetUrls,
			loadStats: LoadStats,
			getStats: GetStats
		};

		return service;

		function AddUrl(longUrl) {
			var deferred = $q.defer();

			var url = {
				longUrl: longUrl
			};

			var httpParams = {
				url: siteRootUrl + 'urlshortener/api/urls',
				method: 'POST',
				data: url
			};

			$http(httpParams).success(success).error(error);

			return deferred.promise;

			function success(addedUrl) {
				// refresh url list
				LoadUrls();
				deferred.resolve(addedUrl);
			}

			function error(err, status) {
				deferred.reject(err);
			};
		}

		function GetUrl(shortUrl) {
			var deferred = $q.defer();

			var httpParams = {
				url: siteRootUrl + 'urlshortener/api/urls/' + shortUrl,
				method: 'GET'
			};

			$http(httpParams).success(success).error(error);

			return deferred.promise;

			function success(data) {
				deferred.resolve(data);
			}

			function error(err, status) {
				deferred.reject(err);
			};
		}

		function LoadUrls() {
			var deferred = $q.defer();

			var httpParams = {
				url: siteRootUrl + 'urlshortener/api/urls',
				method: 'GET'
			};

			$http(httpParams).success(success).error(error);

			return deferred.promise;

			function success(data) {
				// update urls result
				urls.items = data;
				deferred.resolve(data);
			}

			function error(err, status) {
				deferred.reject(err);
			};
		}

		function GetUrls() {
			return urls;
		}

		function LoadStats(shortUrl) {
			var deferred = $q.defer();

			var httpParams = {
				url: siteRootUrl + 'urlshortener/api/urls/' + shortUrl + '/stats',
				method: 'GET'
			};

			$http(httpParams).success(success).error(error);

			return deferred.promise;

			function success(data) {
				// update stats result
				stats.items = data.stats;
				stats.totalCount = data.totalCount;

				deferred.resolve(data);
			}

			function error(err, status) {
				deferred.reject(err);
			};
		}

		function GetStats() {
			return stats;
		}
	}
})();