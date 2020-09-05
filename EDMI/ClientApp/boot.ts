import './css/site.css';
import 'bootstrap';
import Vue from 'vue';
import VueRouter from 'vue-router';

Vue.use(VueRouter);
const routes = [
    { path: '/', name: 'Home', component: require('./components/home/home.vue.html') },
    { path: '/electricMeter', name: 'electManager', component: require('./components/electricMeter/electricMeter.vue.html') },
    { path: '/editElectricMeter/:id', name: 'EditElectricMeter', component: require('./components/electricMeter/updateElectricMeter.vue.html') },
    { path: '/deleteElectricMeter/:id', name: 'RemoveElectricMeter', component: require('./components/electricMeter/deleteElectricMeter.vue.html') },
    { path: '/createElectricMeter', name: 'CreateElectricMeter', component: require('./components/electricMeter/createElectricMeter.vue.html') },

    { path: '/managementWaterMeter', name: 'managementWaterMeter', component: require('./components/waterMeter/management.vue.html') },
    { path: '/updateWaterMeter/:id', name: 'updateWaterMeter', component: require('./components/waterMeter/update.vue.html') },
    { path: '/removeWaterMeter/:id', name: 'removeWaterMeter', component: require('./components/waterMeter/remove.vue.html') },
    { path: '/createWaterMeter', name: 'createWaterMeter', component: require('./components/waterMeter/create.vue.html') },

    { path: '/managementGateways', name: 'managementGateways', component: require('./components/gateways/management.vue.html') },
    { path: '/updateGateways/:id', name: 'updateGateways', component: require('./components/gateways/update.vue.html') },
    { path: '/removeGateways/:id', name: 'removeGateways', component: require('./components/gateways/remove.vue.html') },
    { path: '/createGateways', name: 'createGateways', component: require('./components/gateways/create.vue.html') },

    { path: '/usernew', name: 'usernew', component: require('./components/User/userNew.vue.html') },
];

new Vue({
    el: '#app-root',
    router: new VueRouter({ mode: 'history', routes: routes }),
    render: h => h(require('./components/app/app.vue.html'))
});
