(function() {
    'use strict';

    angular
        .module('ms')
        .directive('educationLevel', educationLevel);

    educationLevel.$inject = [];
    function educationLevel() {
        // Usage:
        //
        // Creates:
        //
        var directive = {
            link: link,
            scope: {
                level:'=',
                change:'&',
                disabled:'@'
            },
            template:'<ul class="nav nav-pills nav-pills-icons nav-pills-primary remove-all-margins fit-content-center" >'+
                                           '<li ng-class="{active:level===3}">'+
                                                '<a role="button" ng-click="changePill(3)" ng-class="{disabled:disabled===\'true\'}">'+
                                                    '<i><img class="ms-logos" src="assets/img/ms-degree-college-logo.png"/></i> Degree College'+
                                                    '</a>'+
                                            '</li>'+
                                            '<li ng-class="{active:level===2}">'+
                                                '<a role="button" ng-click="changePill(2)" ng-class="{disabled:disabled===\'true\'}">'+
                                                    '<i><img class="ms-logos" src="assets/img/ms-junior-logo.png"/></i> Junior'+
                                                    'College'+
                                                '</a>'+
                                            '</li>'+
                                            '<li ng-class="{active:level===1}">'+
                                                '<a role="button" ng-click="changePill(1)" ng-class="{disabled:disabled===\'true\'}">'+
                                                    '<i ><img class="ms-logos" src="assets/img/ms-creative-school-logo.png"/></i>'+
                                                   ' Creative School'+
                                                '</a>'+
                                            '</li>'+
                                            // '<li ng-class="{active:level===\'kids\'}">'+
                                            //     '<a role="button" ng-click="changePill(\'kids\')" ng-class="{disabled:disabled===\'true\'}">'+
                                            //         '<i ><img class="ms-logos" src="assets/img/ms-creative-kids-logo.png"/></i>'+
                                            //         'Kids Shool'+
                                            //     '</a>'+
                                            // '</li>'+
                                        '</ul>'
        };
        return directive;
        
        function link(scope, element, attrs) {
            scope.changePill = function(level){
                if(scope.disabled === 'true'){
                    return;
                }
                scope.level = level;
                scope.change();
            }
        }
    }
    /* @ngInject */
    function ControllerController () {
        
    }
})();