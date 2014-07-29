﻿// Generated by CoffeeScript 1.7.1
(function() {
  SiteAngular.Student.controller('List', [
    '$scope', '$state', 'Factory', function($scope, $state, Factory) {
      Factory.query().$promise.then(function(result) {
        return $scope.students = result;
      });
      return $scope.Delete = function(id) {
        Factory.remove({
          'id': id
        });
        return $state.transitionTo('List', {}, {
          reload: true,
          inherit: true,
          notify: true
        });
      };
    }
  ]);

}).call(this);

//# sourceMappingURL=List.js.map