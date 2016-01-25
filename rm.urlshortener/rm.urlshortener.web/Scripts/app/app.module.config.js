(function () {
    'use strict';

    angular.module('app')
		.constant('siteRootUrl', 'http://localhost:60068/')
		.config(config);

    config.$inject = ['blockUIConfig'];
    function config(blockUIConfig) {
    	/* BlockUI Configuration*/

    	// Change the default delay to 100ms before the blocking is visible
    	blockUIConfig.delay = 200;

    	// Disable automatically blocking of the user interface
    	blockUIConfig.autoBlock = false;

    	// Disable auto body block
    	blockUIConfig.autoInjectBodyBlock = false;
    }

})();