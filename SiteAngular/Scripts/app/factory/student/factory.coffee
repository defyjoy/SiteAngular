# CoffeeScript
SiteAngular.Student.factory 'Factory', ($resource)->
    $resource "api/students/:id", {id:'@id'} ,
        query:
            method:'GET'
            isArray:true
        get:
            params:
                id:"@id"
        update:
            method:'PUT'