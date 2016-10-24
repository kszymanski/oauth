import { expect } from 'chai';
import {DashboardComponent} from '../src/app/components/dashboard/dashboard';
import {app} from '../src/app/app';

describe('MoviesViewModel', () => {
    beforeEach(angular.mock.module(app.app));

    describe('greet', () => {
        //use inject to inject the service into the test function
        it('should return hello + param',
            inject(function(DashboardComponent: DashboardComponent): void {
                DashboardComponent.controller.add();


            }));
    });
});