import Vue from 'vue';
import { Component } from 'vue-property-decorator';

interface item {
    id: string;
    serialNumber: string;
    firmwareVersion: string;
    state: string;
    ip: string;
    port: string;
}

@Component
export default class ManagementGateways extends Vue {
    listData: item[] = [];

    mounted() {
        fetch('api/Gateways/GetAll')
            .then(response => response.json() as Promise<item[]>)
            .then(data => {
                this.listData = data;
            });
    }

}
