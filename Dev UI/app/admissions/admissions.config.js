(function () {
    'use strict';

    angular.module('ms.admissions')
        .run(runConfig);

    runConfig.$inject = ['$rootScope', '$location', '$state', '$transitions', 'lookUps']
    function runConfig($rootScope, $location, $state, $transitions, lookUps) {


        $transitions.onSuccess({}, function (trans) {

            if (!sessionStorage.userDetails && $state.current.name !== 'login') {
                $state.go('login');
                swal({
                    title: 'Logged out',
                    text: 'Please login to proceed',
                    type: 'warning',
                    confirmButtonClass: "btn btn-info",
                    buttonsStyling: false
                }).catch(swal.noop)
            }
        });

    }
})();