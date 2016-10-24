
var templateUrl = require('ngtemplate!html!./dashboard.html');
import {IOrdersResource} from '../../services/orders.service';

    class Dashboard implements ng.IController {
        public textBinding: string;
        public number: number;

        constructor(private orders: IOrdersResource) {
            console.log(this.number);
            console.log(this.textBinding);
            console.log(orders.query());
        }

        add(): void {
            console.log('fire');

        }

    }

    export class DashboardComponent implements ng.IComponentOptions {

        public bindings: any;
        public controller: any;
        public templateUrl: string;

        constructor() {
            this.bindings = {
                textBinding: '@',
                number: '<'
            };
            this.controller = Dashboard;
            this.templateUrl = templateUrl;            
        }

    }