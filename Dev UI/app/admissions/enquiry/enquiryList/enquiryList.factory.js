(function () {
    'use strict';

    angular
        .module('ms')
        .factory('enquiryListFactory', enquiryListFactory);

    enquiryListFactory.$inject = ['$http', '$q', 'apiCollection'];
    function enquiryListFactory($http, $q, apiCollection) {
        var enquiryData = [];
        // {
        //     "enquiryNumber": "0001",
        //     "studentName": "Mohammed Azhar uddin",
        //     "branchName": "Masabtank",
        //     "academicYear": "2018",
        //     "cgpA_Per": "8.5"
        // }, {
        //     "enquiryNumber": "0002",
        //     "studentName": "Abdul Aleem",
        //     "branchName": "Tolichowki",
        //     "academicYear": "2017",
        //     "cgpA_Per": "9.8"
        // }

        var service = {
            getEnquiryList: getEnquiryList,
            getEnquiryGridOptions: getEnquiryGridOptions,
            resetData:resetData
        };

        return service;

        ////////////////

        /* Call to server to get enquiry list
         dataRowStructure : {

         }*/
        function getEnquiryList() {
            var defer = $q.defer();
            if (enquiryData.length === 0) {
                $http.get(apiCollection.enquiry.getAllByUserIdUrl(JSON.parse(sessionStorage.userDetails).data.userId)).then(function (result) {
                    enquiryData = result.data.table;
                    defer.resolve(result.data.table);
                });
            } else {
                defer.resolve(enquiryData);
            }

            return defer.promise;
        }
        function resetData(){
            enquiryData = [];
        }
        function getEnquiryGridOptions() {
            return {
                columns: [
                    { title: "Enquiry No.", data: "enquiryNumber" },
                    { title: "Student Name", data: "studentName" },
                    { title: "Branch Name", data: "branchName" },
                    { title: "Academic Year", data: "academicYear" },
                    { title: "CGPA", data: "cgpaPer" },
                    { title: "Action" }
                ],
                columnDefs: [
                    {
                        targets: 1,
                        render: function (data,type,row) {
                            return '<a role="button" class="btn btn-simple btn-warning btn-icon edit" href="#!/enquiry/view/'+row.id+'">'+row.studentName+'</a>';
                        }
                    },
                    {
                        targets: 5,
                        title: "Action",
                        render: function () {
                            return '<a role="button" class="btn btn-simple btn-warning btn-icon edit"><i class="material-icons">mode_edit</i></a>';
                        }
                    }
                ],
                pagingType: "full_numbers",
                lengthMenu: [
                    [10, 25, 50],
                    [10, 25, 50]
                ],
                responsive: true,
                language: {
                    search: "_INPUT_",
                    searchPlaceholder: "Search records",
                }
            }
        }
    }
})();