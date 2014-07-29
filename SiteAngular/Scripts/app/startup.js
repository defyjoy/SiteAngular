var SiteAngular = {
    Student: angular.module('student', ['ngResource', 'ui.router'])
};

angular.element(document).ready(function () {
    angular.bootstrap(document, ['student']);
});