﻿SiteAngular.Student.controller 'Create',['$scope','$state','Factory', ($scope,$state,Factory) -> 
    $scope.Create=(student)->
       if student is undefined
         toastr.error "Please fill the required input fields"
         return

        Factory.save(student).$promise.then (result)->
            toastr.success "Records for " + result.FirstName + " successfully added."
            $state.go 'List'
        ,(error)->
             console.log error
             toastr.error error.data

   
]

