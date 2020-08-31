import Vue from 'vue';
import { Component } from 'vue-property-decorator';

interface Item {
    id: string;
    serialNumber: string;
    firmwareVersion: string;
    state: string;
    ip: string;
    port: string;
}

@Component
export default class RemoveGateways extends Vue {
    item: Item = {
        id: '',
        serialNumber: '',
        firmwareVersion: '',
        state: '',
        ip: '',
        port: ''
    };
    mounted() {
        let app = this;
        let id = app.$route.params.id;
        console.log(id);
        fetch('api/Gateways/GetById/' + id)
            .then(response => response.json() as Promise<Item>)
            .then(data => {
                console.log(data);
                this.item = data;
            });
    };
    Delete() {
        const data = this.item.id;
        fetch('api/Gateways/Remove', {
            method: 'POST', // or 'PUT'
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        })
            .then(response => this.$router.push('/managementGateways'));
    }
}
