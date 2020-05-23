<template>
  <div>
    <el-container>
      <el-main>
            <Lobby v-if="game.status == 0" />
      <!-- <el-row :gutter="10">
        <el-col :xs="14" :sm="14" :md="16" :lg="18" :xl="18">
          <div class="grid-content bg-purple">
            <Lobby v-if="game.status == 0" />
          </div>
        </el-col>
        <el-col :xs="10" :sm="10" :md="8" :lg="6" :xl="6">
          <div class="grid-content bg-purple-light">

          </div>
        </el-col>
      </el-row> -->
      </el-main>
      <el-aside>
        <PlayerList />
      </el-aside>
    </el-container>
    <button @click="exitGame">Exit</button>

    <!-- {{ game }} -->
    
    
  </div>
</template>

<script lang="ts">
import store from "@/store";
import { Component, Vue, Watch } from 'vue-property-decorator';
import Lobby from '@/components/game/Lobby.vue'
import PlayerList from '@/components/player/PlayerList.vue'
import client from '../client/api-factory';
import { PlayerGameCommand, GameDto } from '../client/api';


@Component({
  components:{
    Lobby,
    PlayerList
  }
})
export default class GameManager extends Vue {

  get game() {
      return store.state.game;
  }

  // @Watch('game')
  // onPropertyChanged(value: GameDto, oldValue: GameDto) {
  //   if(value != null){
      
  //   }
  // }

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
