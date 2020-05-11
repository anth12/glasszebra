<template>
  <div>
    <label>
      Join Code
      <input type="text" v-model="joinCode" />
    </label>
    <button @click="onJoin">Join</button>
  </div>
</template>

<script lang="ts">
import store from "@/store";
import { Component, Vue } from 'vue-property-decorator';
import { GameClient, IGameClient } from '../client/api';

const client: IGameClient = new GameClient('https://localhost:44312');

@Component
export default class JoinGame extends Vue {
  joinCode = "";

  onJoin(): void{

    client.join(this.joinCode).then(response =>{
      store.dispatch('addGameClientId', response.gameClientId);
      store.dispatch('addParticipantClientId', response.participantClientId);
      
      client.get(response.gameClientId ?? '').then(game=>{
        store.dispatch('addGame', game);
      });

    }).catch((e)=>{
      console.log(e);
      alert('Could not join')
    })
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">

</style>
