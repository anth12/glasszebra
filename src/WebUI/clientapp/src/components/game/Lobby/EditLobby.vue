<template>
  <div>
      
      <div v-if="options && update">

        <h1>
          <el-input placeholder="Game Name" v-model="update.name"></el-input>
        </h1>
        <Validation property="Name" />

        <p>Categories:
          <el-checkbox-group v-model="update.categories">
            <el-checkbox v-for="category in options.categories" :label="category.id" :key="category.id">{{category.name}}</el-checkbox>
          </el-checkbox-group>
        </p>
        <Validation property="Categories" />
        
        <p>Difficulty:
          <el-checkbox-group v-model="update.difficulty">
            <el-checkbox-button v-for="(id, name) in options.difficulty" :label="id" :key="id">{{name}}</el-checkbox-button>
          </el-checkbox-group>
        </p>
        <Validation property="Difficulty" />

        <div>
            <label>Number of Rounds
              <el-slider
                v-model="update.numberOfRounds"
                v-bind:max="options.maxNumberOfRounds"
                :step="1">
              </el-slider>
                
                {{ update.numberOfRounds }}
            </label>
        </div>
        <Validation property="NumberOfRounds" />

        <div>
            <label>Questions Per Round
              <el-slider
                v-model="update.questionsPerRound"
                v-bind:max="options.maxQuestionsPerRound"
                :step="5">
              </el-slider>
                {{ update.questionsPerRound }}
            </label>
        </div> 
        <Validation property="QuestionsPerRound" />

      </div>

  </div>
</template>

<script lang="ts">
import store from "@/store";
import { IGetGameOptionsResponse, UpdateGameCommand, ValidationException, NotFoundException } from "@/client/api";
import client from "@/client/api-factory";
import Validation from "@/components/common/Validation.vue";
import { Component, Vue, Watch, Prop } from 'vue-property-decorator';

@Component({
  components:{
    Validation
  }
})
export default class EditLobby extends Vue {
  
  private updateDefer?: NodeJS.Timeout;
  private options: null | IGetGameOptionsResponse = null;
  
  @Prop({
    default: ()=> new UpdateGameCommand({
      gameClientId: store.state.gameClientId,
      playerClientId: store.state.playerClientId,
      name: store.state.game?.name || '',
      questionsPerRound: store.state.game?.questionsPerRound || 0,
      numberOfRounds: store.state.game?.numberOfRounds || 0,
      difficulty: store.state.game?.difficulty || [],
      categories: store.state.game?.categories?.map(c=> c.id || 0) || [],
    })
  }) update?: UpdateGameCommand;
  
  get game() {
      return store.state.game;
  }

  @Watch('update', { deep: true })
  onPropertyChanged() {
      
      if(this.updateDefer)
        clearTimeout(this.updateDefer);      
  
      this.updateDefer = setTimeout(()=>{
          
        if(this.update != null){
          console.log(this.update.questionsPerRound)
            client.update(this.update).then(()=>{              
              store.dispatch('addValidation', null);
            }).catch((e)=>{
              store.dispatch('addValidation', e);              
            })
        }
      }, 500);
  }
  
  mounted() {

    store.commit('isLoading', false);

    client.options().then(response => {
      this.options = response;

    }).catch(response=>{
      console.error('Failed to load options');
      console.error(response);

    }).then(()=>{
      store.commit('isLoading', false);
    });
    
  }

}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">

</style>
