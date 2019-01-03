(function () {
    'use strict';

    angular.module('ms.admissions')
        .config(routeConfig);

    function routeConfig($stateProvider) {
        $stateProvider
            .state({
                name: 'main.enquiryList',
                url:'/enquirylist',
                templateUrl: 'app/admissions/enquiry/enquiryList/enquiryList.html',
                controller:'enquiryList'
            })
            .state({
                name: 'main.enquiry',
                url:'/enquiry/:mode/:id',
                templateUrl: 'app/admissions/enquiry/enquiry.html',
                controller:'enquiryCtrl'
            })
            .state({
                name: 'main.reports',
                url: '/reports',
                templateUrl: 'app/admissions/reports/reports.html',
                controller:'reportsCntrl'
            })
            .state({
                name: 'main.admissionList',
                url: '/admissionList',
                templateUrl: 'app/admissions/admissionPage/admissionList/admissionList.html',
                controller: 'admissionList'
            })
            .state({
                name: 'main.admission',
                url: '/admission/:mode/:educationLevelId/:id/:userId',
                templateUrl: 'app/admissions/admissionPage/admission.html',
                controller: 'admissionCtrl'
            })
            
    }
})();