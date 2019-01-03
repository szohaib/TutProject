(function () {
    'use strict';

    angular
        .module('ms')
        .directive('customDatatable', customDatatable);

    customDatatable.$inject = [];
    function customDatatable() {
        // Usage:
        //
        // Creates:
        //
        var directive = {
            link: link,
            controller: controller,
            scope: {
                options: '=',
                id: '@',
                editBtnAction: '&'
            }
        };
        return directive;

        function link(scope, element, attrs) {

        }
        controler.$inject = ['$scope', '$state','$timeout'];
        function controller($scope, $state,$timeout) {
            if ($scope.options) {
                $scope.options.initComplete = function (settings, json) {
                    addClickEventOnEdit();
                }
                $('#' + $scope.id).DataTable($scope.options);

                $('#' + $scope.id).on('page.dt', function () {
                    $timeout(function () {
                        addClickEventOnEdit()
                    })
                });
            }
            function addClickEventOnEdit() {
                $('#' + $scope.id + ' tbody tr td:last-of-type a').click(function () {
                    var dataRow = $('#' + $scope.id).DataTable().row(this.parentElement.parentElement).data();
                    $scope.editBtnAction({ dataRow: dataRow });
                });
            }
        }
    }
})();
