<template>
  <div>
      <span class="status-connected" >
          Connected
      </span>
    <el-badge :value="2" class="item" type="warning" v-if="status == 1">
        <el-button size="small">replies</el-button>
    </el-badge>
      
      <span class="status-disconnected" v-if="status == 2">
          Disconnected
      </span>
      
      <span class="status-left" v-if="status == 4">
          Left
      </span>
  </div>
</template>

<script lang="ts">
import store from "@/store";
import { Component, Vue, Prop } from 'vue-property-decorator';

@Component
export default class PlayerStatus extends Vue {
    @Prop() private status!: number;
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
.status-connected{
    background-color: green;
}
.status-disconnected{
    background-color: red;
}
.status-left{
    background-color: grey;
}
</style>
