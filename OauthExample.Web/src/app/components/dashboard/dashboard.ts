var templateUrl = require('ngtemplate!html!./dashboard.html');


class Dashboard implements ng.IController {
    public textBinding: string;
    public number: number;

    constructor() {
        console.log(this.number);
        console.log(this.textBinding);
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
