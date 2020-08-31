import Vue from 'vue';
import { Component } from 'vue-property-decorator';

interface ElectricMeter {
    id: string;
    serialNumber: string;
    firmwareVersion: string;
    state: string;
}

@Component
export default class electricMeterComponent extends Vue {
    electricMeters: ElectricMeter[] = [];

    mounted() {
        fetch('api/ElectricMeter/GetAll')
            .then(response => response.json() as Promise<ElectricMeter[]>)
            .then(data => {
                this.electricMeters = data;
            });
    }

}
