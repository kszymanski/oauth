import routing from './routing';
import config from './config';

import * as angular from 'angular';
import uirouter from 'angular-ui-router';
import * as angularResource from 'angular-resource';

export module app {
    export var app = angular.module("name", [uirouter, angularResource]);
    app.config(routing);
    app.constant(config);
}