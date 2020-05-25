<template>
  <div>
      
    <el-card class="box-card" id="playerList">
        <div v-for="player in players" :key="player.id" el-badge is-dot class="item" v-bind:type="statusType(player.status)">
            <el-badge is-dot class="item" v-bind:type="statusType(player.status)" v-bind:title="statusName(player.status)">
                {{player.name}}
            </el-badge>

          <!-- <PlayerStatus v-bind:status="player.status" /> -->


        <el-popconfirm title="Are you sure?" confirmButtonText="Yes" cancelButtonText="No" 
          v-if="canRemovePlayer(player)" v-on:onConfirm="removePlayer(player)">
          <el-link 
            type="danger" 
            icon="el-icon-close"
            size="mini"
            title="Remove player"            
            slot="reference"></el-link>
        </el-popconfirm>
          
          <el-divider></el-divider>
        </div>

        <div class="bottom clearfix">

        <el-popconfirm title="Are you sure?" confirmButtonText="Yes" cancelButtonText="No" 
          v-on:onConfirm="quit()">
          <el-button type="text" class="button" slot="reference">Quit game</el-button>
        </el-popconfirm>
          
        </div>

    </el-card>

  </div>
</template>

<script lang="ts">
import store from "@/store";
import { PlayerStatus, GamePlayerDto, RemovePlayerCommand, PlayerGameCommand } from "@/client/api";
import { Component, Vue, Prop } from 'vue-property-decorator';
import { playerClient, gameClient } from '@/client/api-factory';
import { Message } from 'element-ui';

@Component({
  components:{
  }
})
export default class PlayerList extends Vue {
    
  get players() {
      return store.getters.sortedPlayerList;
  }

  canRemovePlayer(player: GamePlayerDto){
    return store.getters.isGameOwner && store.state.playerId != player.id;
  }

  removePlayer(player: GamePlayerDto){
    playerClient.remove(new RemovePlayerCommand({
      gameClientId: store.state.gameClientId,
      playerClientId: store.state.playerClientId,
      playerId: player.id
    })).catch((e)=>{
      console.log(e);
      Message.error('Something went wrong while removing player')
    });
  }

  quit(){
    gameClient.leave(new PlayerGameCommand({
      gameClientId: store.state.gameClientId,
      playerClientId: store.state.playerClientId,
    })).then(()=>{
      store.dispatch('clear');
    }).catch(e=>{
      console.error('Failed to leave game', e);
      Message.error('Something went wrong while leaving')
    });
  }

    statusType(status: PlayerStatus) {
        switch(status){
            case PlayerStatus.Connected:
                return 'success';
            case PlayerStatus.Disconnected:
                return 'danger';
            case PlayerStatus.Left:
                return 'info';
        }
        return 'info';
    }
    
    statusName(status: PlayerStatus) {
        switch(status){
            case PlayerStatus.Connected:
                return 'Connected';
            case PlayerStatus.Disconnected:
                return 'Disconnected';
            case PlayerStatus.Left:
                return 'Left';
        }
        return 'info';
    }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
#playerList{
  overflow-y: scroll;
  max-height: 85vh;
}
</style>
