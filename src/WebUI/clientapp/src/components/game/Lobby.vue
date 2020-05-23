<template>
  <div>
      
      <h2>Join code: {{game.joinCode}}</h2>

      <EditLobby v-if="isGameOwner" />
      <ViewLobby v-if="!isGameOwner" />
      
      <ul>
        <li v-for="player in game.players" :key="player.id">
          {{player.name}} - 
          <PlayerStatus v-bind:status="player.status" />
        </li>
      </ul>
  </div>
</template>

<script lang="ts">
import store from "@/store";
import { Component, Vue } from 'vue-property-decorator';
import PlayerStatus from "@/components/player/Status.vue";
import EditLobby from './Lobby/EditLobby.vue';
import ViewLobby from './Lobby/ViewLobby.vue';

@Component({
  components:{
    EditLobby,
    ViewLobby,
    PlayerStatus
  }
})
export default class Lobby extends Vue {
  
  get game() {
      return store.state.game;
  }

  get isGameOwner() {
      return store.getters.isGameOwner;
  }

}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">

</style>
