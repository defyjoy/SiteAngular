var SiteAngular = {
    Student: angular.module('student', ['ngResource', 'ui.router','ngAnimate'])
};

angular.element(document).ready(function () {
    angular.bootstrap(document, ['student']);
});