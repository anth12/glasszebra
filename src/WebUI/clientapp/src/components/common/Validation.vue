<template>
    <div>
        {{ property }}
        {{ validation }}
      <p v-for="error in validation" :key="error" class="error">
          {{ error }}
      </p>
    </div>
</template>

<script lang="ts">
import store from "@/store";
import { Component, Vue, Prop } from 'vue-property-decorator';

@Component({})
export default class Validation extends Vue {
  
  @Prop() 
  property: string|undefined;
    
  get validation() {
      return store.getters.getValidationError(this.property || '');
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
.error{
    color: salmon;
}
</style>
