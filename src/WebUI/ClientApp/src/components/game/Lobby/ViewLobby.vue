<template>
  <div>
      
    <h1>{{game.name}}</h1>

    <h4>Waiting for game to start... <span v-loading="true"></span></h4>

    <h3>Categories: </h3>
    <el-tag v-for="category in game.categories" :key="category.id">
      {{category.name }}
    </el-tag>

    <h3>Difficulty: </h3>
    <el-tag v-for="difficulty in game.difficulty" :key="difficulty">
      <Difficulty v-bind:value="difficulty" />
    </el-tag>
        
    <h3>Number Of Rounds: <strong>{{ game.numberOfRounds }}</strong></h3>
    <h3>Questions Per Round: <strong>{{ game.questionsPerRound }}</strong></h3>
    
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
