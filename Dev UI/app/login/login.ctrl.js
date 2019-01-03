(function () {
    'use strict';

    angular
        .module('ms')
        .controller('loginCntrl', loginCntrl);

    loginCntrl.$inject = ['$scope', '$state', 'loginFactory'];
    function loginCntrl($scope, $state, loginFactory) {


        activate();

        ////////////////

        $scope.login = function () {
            loginFactory.login($scope.user).then(function (data) {
                if (data.success)
                    $state.go('main.enquiryList');
                else {
                    swal({
                        title: 'Failed',
                        text: data.data,
                        type: 'error',
                        confirmButtonClass: "btn btn-info",
                        buttonsStyling: false
                    }).catch(swal.noop)
                }
            })

        }

        function activate() { }
    }
})();