import Vue from 'vue';
import { Component } from 'vue-property-decorator';

interface ElectricMeter {
    id: string;
    serialNumber: string;
    firmwareVersion: string;
    state: string;
}

@Component
export default class updateElectricMeter extends Vue {
    electricMeter: ElectricMeter = {
        id: '',
        serialNumber: '',
        firmwareVersion: '',
        state: ''
    };
    mounted() {
        let app = this;
        let id = app.$route.params.id;
        console.log(id);
        fetch('api/ElectricMeter/GetById/' + id)
            .then(response => response.json() as Promise<ElectricMeter>)
            .then(data => {
                console.log(data);
                this.electricMeter = data;
            });
    };
    Update() {
        const data = this.electricMeter;
        fetch('api/ElectricMeter/Update', {
            method: 'POST', // or 'PUT'
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        })
            .then(response => this.$router.push('/electricMeter'));
    }
}
