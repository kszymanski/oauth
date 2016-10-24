
import development from './development';
import production from './production';

var environment = process.env.NODE_ENV === 'production' ? production : development;

export default environment;
