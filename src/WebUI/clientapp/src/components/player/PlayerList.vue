<template>
  <div>
      
    <el-card class="box-card">
        <div v-for="player in game.players" :key="player.id" el-badge is-dot class="item" v-bind:type="statusType(player.status)">
            <el-badge is-dot class="item" v-bind:type="statusType(player.status)">
                {{player.name}}
            </el-badge>

          <!-- <PlayerStatus v-bind:status="player.status" /> -->
          <el-divider></el-divider>
        </div>
    </el-card>

  </div>
</template>

<script lang="ts">
import store from "@/store";
import { PlayerStatus } from "@/client/api";
import { Component, Vue, Prop } from 'vue-property-decorator';
//import PlayerStatus from "@/components/player/Status.vue";

@Component({
  components:{
    //PlayerStatus
  }
})
export default class PlayerList extends Vue {
    
  get game() {
      return store.state.game;
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
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">

</style>
