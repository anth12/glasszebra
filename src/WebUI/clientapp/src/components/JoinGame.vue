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
import client from '../client/api-factory';

@Component
export default class JoinGame extends Vue {
  joinCode = "";

  onJoin(): void{

    client.join(this.joinCode).then(response =>{
      store.dispatch('addGameClientId', response.gameClientId);
      store.dispatch('addPlayerClientId', response.playerClientId);
      store.dispatch('addPlayerId', response.playerId);
      
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
