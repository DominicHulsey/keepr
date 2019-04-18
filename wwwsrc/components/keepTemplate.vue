<template>
  <!-- <div :class="$mq | mq({xxs: 'col-12 p-0',xs: 'col-12 p-0', sm: 'col-12 p-1', md: 'col-6 p-1', lg: 'col-6 p-1'})"> -->
  <div>
    <waterfall :line-gap="400" align="center" :watch="this.keeps" style="max-height:100%;">
      <!-- each component is wrapped by a waterfall slot -->
      <waterfall-slot v-for="(keep, index) in keeps" move-class="item-move1" v-if="keep.width" :width="keep.width"
        :height="keep.height" class="anim" :order="keep.id" :key="keep.id">
        <keep-details :keep="keep"></keep-details>
        <drag :transfer-data="keep" class="keepClass">
          <img data-toggle="modal" @click="addCount(keep, 'views')" :data-target="'#Modal' + keep.id" class="keepImage"
            :index="keep.id" :src="keep.img" />
          <div class="overlay">
            <p class="text">{{keep.name}}</p>
            <div class="row justify-content-around">
              <div class="bg-primary"><i class="fas fa-eye"></i>
                <p> Views</p>
              </div>
              <div class="bg-primary"><i class="fas fa-praying-hands"></i>
                <p> Keeps</p>
              </div>
              <div class="bg-primary"><i class="fas fa-share"></i>
                <p> Shares</p>
              </div>
            </div>
          </div>
        </drag>
      </waterfall-slot>
    </waterfall>
    <!-- <button class="btn btn-outline-danger mb-3" @click="deleteKeep(keep.id)">Delete</button> -->
  </div>
</template>


<script>
  import { Drag, Drop } from 'vue-drag-drop';
  import Waterfall from 'vue-waterfall/lib/waterfall';
  import WaterfallSlot from 'vue-waterfall/lib/waterfall-slot';
  import KeepDetails from '/Users/dominichulsey/source/codeworks/keepr/wwwsrc/components/keepDetails.vue'
  export default {
    name: 'keepTemplate',
    props: ["imageIndex"],
    mounted() {
      console.log(Waterfall)
    },
    data() {
      return {
        showDetails: false,
      }
    },
    computed: {
      imageData() {
        let imgArray = this.images.map(image => {
          return image.image
        })
        let newArray = this.$store.state.keeps.filter(keep => {
          if (imgArray.includes(keep.img)) {
            return keep
          }
        })
        return newArray
      },
      keeps() {
        return this.$store.getters.keeps
      }
    },
    methods: {
      deleteKeep(id) {
        this.$store.dispatch("deleteKeep", id)
      },
      myListener(wassup) {
        console.log("dragging")
      },
      addCount(keep, toAdd) {
        let payload = {
          keepData: keep,
          choice: toAdd
        }
        this.$store.dispatch("addCount", payload)
      }
    },
    components: {
      Drag,
      Drop,
      Waterfall,
      WaterfallSlot,
      KeepDetails
    }
  }
</script>


<style scoped>
  #keepButtons {
    transition: all 0.1s linear;
  }

  #keepButtons:hover {
    box-shadow: 1px 1px 2px black;
    background-color: #60a7f4 !important;
    transform: scale(1.02);
    cursor: pointer;
  }

  .sizing {
    max-width: 100%;
  }

  .item-move {
    transition: all .5s cubic-bezier(.55, 0, .1, 1) !important;
  }

  .item-move1 {
    transition: ease-in
  }


  #keepButtons:active {
    box-shadow: none;
    background-color: #007bff !important;
    transform: scale(1.01);
  }

  .bg-color {
    background-color: black;
  }

  .anim {
    transition: .5s cubic-bezier(.55, 0, .1, 1);
  }

  .vue-waterfall {
    overflow: visible !important
  }

  .keepClass {
    position: relative;
    width: 100%;
  }

  .keepImage {
    display: block;
    width: 100%;
    height: auto;
  }

  .text {
    color: white;
    font-size: 10px;
    position: absolute;
    top: 25%;
    left: 50%;
    transform: translate(-50%, -50%);
    text-align: center;
  }

  .overlay {
    position: absolute;
    bottom: 0;
    left: 0;
    right: 0;
    background-color: #008CBA;
    overflow: hidden;
    width: 100%;
    height: 0;
    transition: .5s ease;
  }

  .keepClass:hover .overlay {
    height: 35%;
  }
</style>