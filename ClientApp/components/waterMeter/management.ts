import Vue from 'vue';
import { Component } from 'vue-property-decorator';

interface item {
    id: string;
    serialNumber: string;
    firmwareVersion: string;
    state: string;
}

@Component
export default class electricMeterComponent extends Vue {
    listData: item[] = [];

    mounted() {
        fetch('api/WaterMeter/GetAll')
            .then(response => response.json() as Promise<item[]>)
            .then(data => {
                this.listData = data;
            });
    }

}
