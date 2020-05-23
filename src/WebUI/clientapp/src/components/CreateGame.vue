<template>
  <div>
    <label>
      Name
      <input type="text" v-model="newGameName" />
    </label>

    <button @click="createGame">Create game</button>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator';
import { client } from '../client/api-factory';
import { CreateGameCommand } from '../client/api';
import store from '../store';

@Component
export default class CreateGame extends Vue {
  newGameName = "";

  createGame(): void{

    client.create(new CreateGameCommand({
      name: this.newGameName
    })).then((response)=>{
      store.dispatch('addGameClientId', response.gameClientId);
      store.dispatch('addPlayerClientId', response.playerClientId);
      
      client.get(response.gameClientId ?? '').then(game=>{
        store.dispatch('addGame', game);
      });

    }).catch((e)=>{
      console.log(e);
    })
  }

}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">

</style>
