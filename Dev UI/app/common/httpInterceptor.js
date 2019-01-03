(function () {
    'use strict';

    angular
        .module('ms')
        .service('httpInterceptor', httpInterceptor);

    httpInterceptor.$inject = ['$rootScope', '$log', '$q'];
    function httpInterceptor($rootScope, $log, $q) {

        var xhrCreations = 0;
        var xhrResolutions = 0;

        function isLoading() {
            return xhrResolutions < xhrCreations;
        }

        function updateStatus() {
            $rootScope.loading = isLoading();
        }

        return {
            request: function (config) {
                xhrCreations++;

                if (sessionStorage.userDetails) {
                    config.headers.Authorization = 'Bearer ' + JSON.parse(sessionStorage.userDetails).access_token;
                }
                updateStatus();
                return config;
            },
            requestError: function (rejection) {
                xhrResolutions++;
                updateStatus();
                $log.error('Request error:', rejection);
                return $q.reject(rejection);
            },
            response: function (response) {
                xhrResolutions++;
                updateStatus();
                return response;
            },
            responseError: function (rejection) {
                xhrResolutions++;
                updateStatus();
                //var title,text;
                // if (rejection.status === 404) {
                //     title   
                // }else{

                // }

                swal({
                    title: '' + rejection.status,
                    text: rejection.statusText,
                    type: 'error',
                    confirmButtonClass: "btn btn-info",
                    buttonsStyling: false
                }).catch(swal.noop)

                $log.error('Response error:', rejection);
                return $q.reject(rejection);
            }
        };

    }
})();