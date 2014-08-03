﻿// Generated by CoffeeScript 1.7.1
(function() {
  SiteAngular.Student.controller('Edit', [
    '$scope', '$state', '$stateParams', 'Factory', function($scope, $state, $stateParams, factory) {
      factory.get({
        id: $stateParams.id
      }).$promise.then(function(result) {
        return $scope.student = result;
      }, function(error) {
        return toastr.error(error.data.Message);
      });
      return $scope.Update = function(id, student) {
        if (student === void 0) {
          toastr.error("Please input correct values");
        }
        return factory.update({
          id: id
        }, student).$promise.then(function(result) {
          return $state.transitionTo('List', {}, {
            reload: true,
            inherit: true,
            notify: true
          });
        }, function(error) {
          return toastr.error(error.data);
        });
      };
    }
  ]);

}).call(this);

//# sourceMappingURL=Edit.js.map