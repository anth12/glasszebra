<template>
  <div>
      
      <h1>{{game.name}}</h1>
      <ul>
        
      </ul>

    <h3>Categories: </h3>
    <p>
      <button v-for="category in game.categories" :key="category.id">
        {{category.name }}
      </button>
     </p>

    <h3>Difficulty: </h3>
    <p>
      <button v-for="difficulty in game.difficulty" :key="difficulty">
        <Difficulty v-bind:value="difficulty" />
      </button>
     </p>   
      <p>numberOfRounds: {{ game.numberOfRounds }}</p>
      <p>questionsPerRound: {{ game.questionsPerRound }}</p>

  </div>
</template>

<script lang="ts">
import store from "@/store";
import Difficulty from "@/components/common/Difficulty.vue";
import { Component, Vue } from 'vue-property-decorator';

@Component({
  components:{
    Difficulty
  }
})
export default class ViewLobby extends Vue {
  
  get game() {
      return store.state.game;
  }

}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">

</style>
