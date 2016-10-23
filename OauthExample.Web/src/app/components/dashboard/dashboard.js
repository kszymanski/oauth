"use strict";
var Dashboard = (function () {
    function Dashboard($scope) {
        this.$scope = $scope;
        $scope.text = "text";
        $scope.show = this.show;
    }
    Dashboard.prototype.show = function (text) {
        alert(text);
    };
    return Dashboard;
}());
exports.Dashboard = Dashboard;
//# sourceMappingURL=dashboard.js.map