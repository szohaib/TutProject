(function () {
    'use strict';

    angular.module('ms')
        .config(appConfig)

    appConfig.$inject = ['$httpProvider','$logProvider'];
    function appConfig($httpProvider,$logProvider) {
        $httpProvider.interceptors.push('httpInterceptor');
        $logProvider.debugEnabled(true);
    }

})();