<template>
  <div>
    <el-button type="primary" @click="triggerCreateGame">Create game</el-button>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator';
import { gameClient } from '@/client/api-factory';
import { CreateGameCommand } from '../client/api';
import store from '../store';

@Component
export default class CreateGame extends Vue {
  newGameName = "";

  triggerCreateGame(): void{

    this.$prompt('Please enter a name for your game', 'Create new Game', {
          confirmButtonText: 'OK',
          cancelButtonText: 'Cancel',
          inputPattern: /^.{3,55}$/,
          inputErrorMessage: 'Name must be between 3 & 55 characters'
        }).then(( value: any ) => {
          this.newGameName = value.value;
          this.createGame();
        });
  }

  createGame(): void{

    store.commit('isLoading', true);

    gameClient.create(new CreateGameCommand({
      name: this.newGameName
    })).then((response)=>{
      store.dispatch('addGameClientId', response.gameClientId);
      store.dispatch('addPlayerClientId', response.playerClientId);
      store.dispatch('addPlayerId', response.playerId);
      
      gameClient.get(response.gameClientId ?? '').then(game=>{
        store.dispatch('addGame', game);
        this.$router.push(game.joinCode)
      });

    }).catch((e)=>{
      console.log(e);
    }).then(()=>{
        store.commit('isLoading', false);
    })

  }

}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">

</style>
