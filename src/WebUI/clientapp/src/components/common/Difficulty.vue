<template>
    <span>
      <span v-if="value == 1">Easy</span>
      <span v-if="value == 2">Average</span>
      <span v-if="value == 4">Hard</span>
      <span v-if="value == 8">Extra Hard</span>      
    </span>
</template>

<script lang="ts">
import store from "@/store";
import { Component, Vue, Prop } from 'vue-property-decorator';

@Component({})
export default class Difficulty extends Vue {
  
  @Prop() 
  value?: number;
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">

</style>
