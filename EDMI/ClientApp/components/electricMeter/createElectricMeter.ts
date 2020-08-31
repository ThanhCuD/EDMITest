import Vue from 'vue';
import { Component } from 'vue-property-decorator';

interface CreateParam {
    serialNumber: string;
    firmwareVersion: string;
    state: string;
}

@Component
export default class CreateElectricMeter extends Vue {
    param: CreateParam = {
        serialNumber: '',
        firmwareVersion: '',
        state: ''
    };
   
    Create() {
        const data = this.param;
        fetch('api/ElectricMeter/Create', {
            method: 'POST', // or 'PUT'
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        })
            .then(response => this.$router.push('/electricMeter'));
    }
}
