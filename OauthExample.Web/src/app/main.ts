require("./styles.scss");
require("imports?jQuery=jquery!../../node_modules/bootstrap-sass/assets/javascripts/bootstrap.js");

import {app} from './app';
import {DashboardComponent} from './components/dashboard/dashboard';
import {OrderResource} from './services/orders.service';

export module abovo{
    
    app.app.component('dashboard', new DashboardComponent());
    app.app.factory('orders', ['$resource', 'apiUrl', ($resource, apiUrl) => OrderResource.Get($resource, apiUrl)]);
}