(function () {
    'use strict';

    angular
        .module('ms')
        .factory('layoutFactory', Service);

    Service.$inject = ['$state', '$q', '$http', 'apiCollection','$log', 'lookUps'];
    function Service($state, $q, $http, apiCollection, $log, lookUps) {
        var feeData = {};
        var feeDataLoaded = true;
        
        return {
            loadFeeStructure: loadFeeStructure,
            getFeeData:getFeeData,
            getFeeGridOptions: getFeeGridOptions,
           
        };

      
        function getFeeData(){
             return feeData;
             console.log(feeData)
        }
        ////////////////
        function loadFeeStructure(educationLevelId,branchId,userId) {
                return $http.get(apiCollection.feeStructure.getByIds(educationLevelId,branchId,userId)).then(function(response){
                 feeData = response.data;
                 feeDataLoaded = true;
                 return feeData;
                 console.log(feeData)
              })
              
        }

        function getFeeGridOptions() {
            return {
                columns: [
                    { title: "Course", data: "courseName" },
                    { title: "Total Fee", data: "totalFees" },
                    { title: "Admission fee", data: "administrativeFees" },
                    { title: "Tution Fee", data: "tutionFees" },
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