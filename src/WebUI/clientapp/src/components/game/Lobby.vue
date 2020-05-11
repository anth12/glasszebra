<template>
  <div>
      {{ game }}

      <h1>{{game.name}}</h1>
      <h2>Join code: {{game.joinCode}}</h2>
      <ul>
        <li v-for="participant in game.participants" :key="participant.id">
          {{participant.name}}
        </li>
      </ul>
  </div>
</template>

<script lang="ts">
import store from "@/store";
import { Component, Vue } from 'vue-property-decorator';

@Component
export default class Lobby extends Vue {
  
  get game() {
      return store.state.game;
  }

}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">

</style>
