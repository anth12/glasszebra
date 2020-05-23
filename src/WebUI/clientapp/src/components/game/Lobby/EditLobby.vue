<template>
  <div>
      
      <div v-if="options && update">

        <h1>
          <input type="text" v-model="update.name" />
        </h1>
        <Validation property="Name" />

        <p>Categories: 
            <button v-for="category in options.categories" :key="category.id">
                <label>
                    {{ category.name }}
                    <input type="checkbox" :id="category.name" :value="category.id" v-model="update.categories">
                </label>
            </button>
        </p>
        <Validation property="Categories" />
        
        <p>Difficulty: 
            <button v-for="(id, name) in options.difficulty" v-bind:key="id">
                <label>
                    {{ name }}
                    <input type="checkbox" v-bind:value="id" v-model="update.difficulty">
                </label>
            </button>
        </p>
        <Validation property="Difficulty" />

        <div>
            <label>Number of Rounds
                <input name="update.numberOfRounds" type="range" min="1" v-bind:max="options.maxNumberOfRounds" v-model.number="update.numberOfRounds">
                {{ update.numberOfRounds }}
            </label>
        </div>
        <Validation property="NumberOfRounds" />

        <div>
            <label>Questions Per Round
                <input name="update.questionsPerRound" type="range" min="5" step="5" v-bind:max="options.maxQuestionsPerRound" v-model.number="update.questionsPerRound">
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
