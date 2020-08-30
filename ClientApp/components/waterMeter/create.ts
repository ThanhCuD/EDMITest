import Vue from 'vue';
import { Component } from 'vue-property-decorator';

interface CreateParam {
    serialNumber: string;
    firmwareVersion: string;
    state: string;
}

@Component
export default class CreateWaterMeter extends Vue {
    param: CreateParam = {
        serialNumber: '',
        firmwareVersion: '',
        state: ''
    };
   
    Create() {
        const data = this.param;
        fetch('api/WaterMeter/Create', {
            method: 'POST', // or 'PUT'
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        })
            .then(response => this.$router.push('/managementWaterMeter'));
    }
}
