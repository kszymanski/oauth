require("./styles.scss");
require("imports?jQuery=jquery!../../node_modules/bootstrap-sass/assets/javascripts/bootstrap.js");
import * as angular from 'angular';
import uirouter from 'angular-ui-router';

import routing from './routing';
import {DashboardComponent} from './components/dashboard/dashboard';

module abovo{
    angular.module("name", [uirouter])
        .config(routing);
    angular.module("name").component('dashboard', new DashboardComponent());
}