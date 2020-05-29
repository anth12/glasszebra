<template>
  <div>
    <label>
      Join Code
      <el-input
        type="text"
        placeholder="e.g. AC35"
        v-model="joinCode"
        minlength="4"
        maxlength="10"
        show-word-limit />
    </label>
    <el-button type="success" @click="onJoin">Join</el-button>
  </div>
</template>

<script lang="ts">
import store from "@/store";
import { Component, Vue } from 'vue-property-decorator';
import { gameClient } from '@/client/api-factory';

@Component
export default class JoinGame extends Vue {
  joinCode = "";

  onJoin(): void{

    gameClient.join(this.joinCode).then(response =>{
      store.dispatch('addGameClientId', response.gameClientId);
      store.dispatch('addPlayerClientId', response.playerClientId);
      store.dispatch('addPlayerId', response.playerId);
      
      gameClient.get(response.gameClientId ?? '').then(game=>{
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
