import Vue from 'vue';
import { Component } from 'vue-property-decorator';

interface CreateParam {
    serialNumber: string;
    firmwareVersion: string;
    state: string;
    ip: string,
    port:string
}

@Component
export default class CreateGateways extends Vue {
    param: CreateParam = {
        serialNumber: '',
        firmwareVersion: '',
        state: '',
        ip: '',
        port: ''
    };
   
    Create() {
        const data = this.param;
        fetch('api/Gateways/Create', {
            method: 'POST', // or 'PUT'
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        })
            .then(response => this.$router.push('/managementGateways'));
    }
}
