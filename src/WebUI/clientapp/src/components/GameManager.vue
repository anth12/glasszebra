<template>
  <div>
    <button @click="exitGame">Exit</button>

    <!-- {{ game }} -->
    
    <Lobby v-if="game.status == 0" />
  </div>
</template>

<script lang="ts">
import store from "@/store";
import { Component, Vue, Watch } from 'vue-property-decorator';
import Lobby from '@/components/game/Lobby.vue'
import { client } from '../client/api-factory';
import { PlayerGameCommand, GameDto } from '../client/api';


@Component({
  components:{
    Lobby
  }
})
export default class GameManager extends Vue {

  get game() {
      return store.state.game;
  }

  @Watch('game')
  onPropertyChanged(value: GameDto, oldValue: GameDto) {
    if(value != null){
      console.log('test');
    }
  }

  exitGame(){
    client.leave(new PlayerGameCommand({
      gameClientId: store.state.gameClientId,
      playerClientId: store.state.playerClientId,
    })).then(()=>{
      store.dispatch('clear');
    }).catch(e=>{
      console.error('Failed to leave game', e);
    });
    
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">

</style>
