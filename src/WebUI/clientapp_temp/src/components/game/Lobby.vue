<template>
  <div>
      
      <h2>Join code: {{game.joinCode}}</h2>

      <EditLobby v-if="isGameOwner" />
      <ViewLobby v-if="!isGameOwner" />
      
  </div>
</template>

<script lang="ts">
import store from "@/store";
import { Component, Vue } from 'vue-property-decorator';
import EditLobby from './Lobby/EditLobby.vue';
import ViewLobby from './Lobby/ViewLobby.vue';

@Component({
  components:{
    EditLobby,
    ViewLobby
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
