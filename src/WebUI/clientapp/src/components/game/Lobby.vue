<template>
  <div>
      
      <h1>{{game.name}}</h1>
      <h2>Join code: {{game.joinCode}}</h2>
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

@Component({
  components:{
    PlayerStatus
  }
})
export default class Lobby extends Vue {
  
  get game() {
      return store.state.game;
  }

}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">

</style>
